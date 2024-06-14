import React from 'react';
import { Route, Switch } from 'react-router-dom';
import { CustomerList } from './CustomerList';
import { ManageCustomer } from './ManageCustomer';

function Customers({ match }) {
    const { path } = match;

    return (
        <Switch>
            <Route exact path={path} component={CustomerList} />
            <Route path={`${path}/add`} component={ManageCustomer} />
            <Route path={`${path}/edit/:id`} component={ManageCustomer} />
        </Switch>
    );
}

export { Customers };