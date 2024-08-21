import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter as Router } from 'react-router-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { Provider } from 'react-redux';
import store from './store';
import { UserProvider } from './store/UserContext';
import { ToastContainer} from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <Router>
      <Provider store={store}>
        <UserProvider>
          <App/>
          <ToastContainer/>
        </UserProvider>
      </Provider>
    </Router>
);
reportWebVitals();
