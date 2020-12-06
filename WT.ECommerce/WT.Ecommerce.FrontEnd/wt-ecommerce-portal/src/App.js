import './App.css';
import {AuthProvider} from './providers/authProvider';
import {BrowserRouter} from 'react-router-dom'
import {Routes} from './routes/routes'


function App() {
  return (
    <div className="App">
         <AuthProvider>
            <BrowserRouter children={Routes} basename={"/"}></BrowserRouter>
         </AuthProvider>
    </div>
  );
}

export default App;
