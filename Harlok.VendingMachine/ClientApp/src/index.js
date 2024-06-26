import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import {createRoot} from 'react-dom/client';
import {BrowserRouter} from 'react-router-dom';
// import App from './App';
import * as serviceWorkerRegistration from './serviceWorkerRegistration';
import {App} from "./App";
import {Provider} from "react-redux";
import {store} from "./store/store";

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');
const root = createRoot(rootElement);

root.render(
    <Provider store={store}>
        <BrowserRouter basename={baseUrl}>
            <App/>
        </BrowserRouter>
    </Provider>
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://cra.link/PWA
serviceWorkerRegistration.unregister();


