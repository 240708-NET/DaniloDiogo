import { Route, Routes } from 'react-router-dom';
import './App.css';
import Home from './page/Home';
import About from './page/About';
import Contact from './page/Contact';
import ErrorPage from './page/ErrorPage';

function App() {
  return (
    <div className="App">
      <Routes>
          <Route path='/' element={<Home/>} />
          <Route path='/about' element={<About/>} />
          <Route path='/contact/:param' element={<Contact />} />
          <Route path='*' element={<ErrorPage/>} />
      </Routes>
    </div>
  );
}

export default App;
