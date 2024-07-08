import React from 'react';
import {Home, Login, Public} from './screens/';
import {Routes, Route} from 'react-router-dom';
import paths from './ultis/path';
export default function App() {
  return (
    <div>
      <Routes>
        <Route path={paths.PUBLIC} element={<Public/>}>
          <Route path={paths.HOME} element={<Home/>}/>
          <Route path={paths.LOGIN} element={<Login/>}/>
        </Route>
      </Routes>
    </div>
  )
}
