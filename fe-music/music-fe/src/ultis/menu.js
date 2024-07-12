import icons from "./icon"

const {FaHome, MdOutlineLibraryMusic, FaUserFriends, FaHeart, MdAlbum}=icons;
export const sidebarMenu=[
    {
        path: '',
        text: 'Home',
        icon: <FaHome size={24}/>
    },
    {
        path: 'album',
        text: 'Album',
        icon: <MdAlbum size={24}/>
    },
    {
        path: 'artists',
        text: 'Artists',
        icon: <FaUserFriends size={24}/>
    },
    {
        path: 'my-favourite',
        text: 'Favourite',
        icon: <FaHeart size={24}/>
    },
    {
        path: 'my-playlist',
        text: 'My Playlists',
        icon: <MdOutlineLibraryMusic size={24}/>
    },
]