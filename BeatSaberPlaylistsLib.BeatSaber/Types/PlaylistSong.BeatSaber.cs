#if BeatSaber
extern alias BeatSaber;
using System;
using System.Runtime.Serialization;

namespace BeatSaberPlaylistsLib.Types
{
    public abstract partial class PlaylistSong : IPlaylistSong
    {
        [NonSerialized]
        private PlaylistLevel? beatmapLevel;

        ///<inheritdoc/>
        [IgnoreDataMember]
        public PlaylistLevel? BeatmapLevel
        {
            get
            {
                if (beatmapLevel != null)
                    return beatmapLevel;

                if (LevelId == null || LevelId.Length == 0)
                    return null;

                var songcoreLevel = SongCore.Loader.GetLevelById(LevelId);

                if (songcoreLevel != null)
                {
                    beatmapLevel = new PlaylistLevel(this, songcoreLevel);
                }

                return beatmapLevel;
            }
            set => beatmapLevel = value != null ? new PlaylistLevel(this, value) : null;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public void RefreshFromSongCore()
        {
            if (LevelId != null && LevelId.Length > 0)
            {
                // PreviewBeatmapLevel = SongCore.Loader.GetLevelById(LevelId);
            }
        }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}

#endif