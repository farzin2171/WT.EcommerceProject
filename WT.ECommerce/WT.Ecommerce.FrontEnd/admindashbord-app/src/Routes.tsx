import * as React from "react";

import { Route, Switch } from "react-router-dom";

import PublicPage from "./Components/Pages/PublicPage"
import PrivatePage from "./Components/Pages/PrivatePage"
import SignIn from './Components/Pages/SignIn'


export const Routes = (
    <Switch>
        <Route path="/dashboard" component={PrivatePage} />
        <Route path="/SignIn" component={SignIn} />
        <Route path="/" component={PublicPage} />
    </Switch>
);