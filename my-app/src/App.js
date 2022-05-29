import './App.css';
import {Home} from './Home';
import {Department} from './Department';
import {Employee} from './Employee';
import {Navigation} from './Navigation';

import {BrowserRouter, Route, Routes} from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
   <div className="container">
     <div className="m-3 d-flex justify-content-center">
              WebAPI
     </div> 
     <Navigation/>
      <Routes>
        <Route path="/home" component={<Home/>}/>
        <Route path="/department" element={<Department/>}/>
        <Route path="employee" element={<Employee/>}/>
      </Routes>
   </div> 
   </BrowserRouter>
  );
}

export default App;
