extern alias BeatSaber;

namespace BeatSaberPlaylistsLib.Types
{
    /// <summary>
    /// Represents a playlist-based level pack.
    /// </summary>
    public class PlaylistLevelPack : BeatSaber::BeatmapLevelPack
    {
        /// <summary>
        /// The playlist associated with this collection of levels.
        /// </summary>
        public IPlaylist playlist { get; }

        internal PlaylistLevelPack(IPlaylist playlist)
            : base(playlist.ID, playlist.Title, playlist.Title, playlist.Sprite, playlist.SmallSprite, playlist.BeatmapLevels, BeatSaber::PlayerSensitivityFlag.Unknown)
        {
            this.playlist = playlist;
        }
    }
}
