import * as React from "react";

import { Route, Switch } from "react-router-dom";

import PublicPage from "./Components/Pages/PublicPage"
import PrivatePage from "./Components/Pages/PrivatePage"
import SignIn from './Components/Pages/SignIn'
import  ProductPage from './Components/Pages/Products/ProductsPage'


export const Routes = (
    <Switch>
        <Route path="/dashboard" component={PrivatePage} />
        <Route path="/products" component={ProductPage} />
        <Route path="/SignIn" component={SignIn} />
        <Route path="/" component={PublicPage} />
    </Switch>
);