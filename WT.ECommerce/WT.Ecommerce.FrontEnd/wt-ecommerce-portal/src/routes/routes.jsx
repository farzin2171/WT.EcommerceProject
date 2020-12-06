import * as React from "react";
import { Route, Switch } from "react-router-dom";


import { Callback } from "../components/auth/callback";
import { Logout } from "../components/auth/logout";
import { LogoutCallback } from "../components/auth/logoutCallback";
import { PrivateRoute } from "./privateRoute";
import { Register } from "../components/auth/register";
import { SilentRenew } from "../components/auth/silentRenew";
import {Bugs} from '../components/Bugs'




export const Routes = (
    <Switch>
        <Route exact={true} path="/SignIn" component={Callback} />
        <Route exact={true} path="/logout" component={Logout} />
        <Route exact={true} path="/logout/callback" component={LogoutCallback} />
        <Route exact={true} path="/register" component={Register} />
        <Route exact={true} path="/silentrenew" component={SilentRenew} />
        <PrivateRoute path="/dashbord" component={Bugs}></PrivateRoute>

    </Switch>
);