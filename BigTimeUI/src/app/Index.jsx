import React from 'react';
import { Route, Switch, Redirect, useLocation } from 'react-router-dom';
import { Nav, Alert } from '@/components';
import { Home } from '@/home';
import { Customers } from '@/customers';

function App() {
    const { pathname } = useLocation();

    return (
        <div className="app-container bg-light">
            <Nav />
            <Alert />
            <div className="container pt-4 pb-4">
                <Switch>
                    <Redirect from="/:url*(/+)" to={pathname.slice(0, -1)} />
                    <Route exact path="/" component={Home} />
                    <Route path="/customers" component={Customers} />
                    <Redirect from="*" to="/" />
                </Switch>
            </div>
        </div>
    );
}

export { App }; 