import * as React from 'react';
import GuestLayout from "@Layouts/GuestLayout";
import AuthorizedLayout from '@Layouts/AuthorizedLayout';
import AppRoute from "@Components/shared/AppRoute";
import HomePage from '@Pages/HomePage';
import { Switch } from 'react-router-dom';
import NotFoundPage from '@Pages/NotFoundPage';
import UsersPage from './pages/UserPage';
import LoginPage from '@Pages/LoginPage';
import ProductsPage from '@Pages/ProductsPage';

export const routes = <Switch>
    <AppRoute layout={AuthorizedLayout} exact path="/" component={HomePage} />
    <AppRoute layout={AuthorizedLayout} exact path="/login" component={LoginPage} />
    <AppRoute layout={AuthorizedLayout} exact path="/users" component={UsersPage} />
    <AppRoute layout={AuthorizedLayout} exact path="/products" component={ProductsPage} />
    <AppRoute layout={GuestLayout} path="*" component={NotFoundPage} statusCode={404} />
</Switch>;