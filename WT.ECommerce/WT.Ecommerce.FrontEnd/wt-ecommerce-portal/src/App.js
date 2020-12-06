import './App.css';
import {AuthProvider} from './providers/authProvider';
import {BrowserRouter} from 'react-router-dom'
import {Routes} from './routes/routes'
import {Header} from './components/Header' 
import {Footer} from './components/Footer'


function App() {
  return (
    <div className="App">
         
         <AuthProvider>
            <Header></Header>
            <BrowserRouter children={Routes} basename={"/"}></BrowserRouter>
         </AuthProvider>
           <Footer></Footer>
    </div>
  );
}

export default App;
