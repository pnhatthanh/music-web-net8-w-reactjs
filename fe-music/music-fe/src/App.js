import React from 'react';
import {Home, AlbumDetail, Public, Album, Artist, ArtistDetail, Login, Favourite} from './pages/';
import {Routes, Route} from 'react-router-dom';
import paths from './ultis/path';
import Register from './pages/Register';
export default function App() {
  return (
    <div>
      <Routes>
        <Route path={paths.PUBLIC} element={<Public/>}>
          <Route path={paths.HOME} element={<Home/>}/>
          <Route path={paths.ALBUM_TITLE_ID} element={<AlbumDetail />}/>
          <Route path={paths.ALBUM} element= {<Album />}/>
          <Route path={paths.ARTIST} element= {<Artist/>}/>
          <Route path={paths.ARTIST_NAME_ID} element={<ArtistDetail/>}/>
          <Route path={paths.FAVOURITE} element={<Favourite/>}/>
        </Route>
        <Route path={paths.LOGIN} element={<Login/>}/>
        <Route path={paths.REGISTER} element={<Register/>}/>
      </Routes>
    </div>
  )
}
