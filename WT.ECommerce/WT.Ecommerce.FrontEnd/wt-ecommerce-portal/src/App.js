import './App.css';
import {AuthProvider} from './providers/authProvider';
import {BrowserRouter} from 'react-router-dom'
import {Routes} from './routes/routes'
import {Header} from './components/Header' 


function App() {
  return (
    <div className="App">
         
         <AuthProvider>
            <Header></Header>
            <BrowserRouter children={Routes} basename={"/"}></BrowserRouter>
         </AuthProvider>
    </div>
  );
}

export default App;
