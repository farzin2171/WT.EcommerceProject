import './App.css';
import {IDENTITY_CONFIG} from './utils/authConst'
import authService from './services/authService'

function App() {
  const service=new authService();
  service.signinRedirect();
  console.log(IDENTITY_CONFIG);
  return (
    <div className="App">
       
    </div>
  );
}

export default App;
