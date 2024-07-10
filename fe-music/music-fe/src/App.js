import React from 'react';
import {Home, AlbumDetail, Public, Album} from './screens/';
import {Routes, Route} from 'react-router-dom';
import paths from './ultis/path';
export default function App() {
  return (
    <div>
      <Routes>
        <Route path={paths.PUBLIC} element={<Public/>}>
          <Route path={paths.HOME} element={<Home/>}/>
          <Route path={paths.ALBUM_TITLE_ID} element={<AlbumDetail />}/>
          <Route path={paths.ALBUM} element= {<Album />}/>
        </Route>
      </Routes>
    </div>
  )
}
