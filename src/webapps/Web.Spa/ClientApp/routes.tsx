import * as React from 'react';
import GuestLayout from "@Layouts/GuestLayout";
import AuthorizedLayout from '@Layouts/AuthorizedLayout';
import AppRoute from "@Components/shared/AppRoute";
import HomePage from '@Pages/public-side/HomePage';
import { Switch } from 'react-router-dom';
import NotFoundPage from '@Pages/NotFoundPage';
import UsersPage from './pages/public-side/UserPage';
import LoginPage from '@Pages/public-side/LoginPage';
import ProductsPage from '@Pages/public-side/ProductsPage';
import AdminLayout from '@Layouts/Admin-Layout';
import CustomerAdminPage from '@Pages/admin/Customer-Admin-Page';
import ProductAdminPage from '@Pages/admin/Product-Admin-Page';
import DashboardAdminPage from '@Pages/admin/Dashboard-Admin-Page';

export const routes = <Switch>
    <AppRoute layout={AuthorizedLayout} exact path="/" component={HomePage} />
    <AppRoute layout={AuthorizedLayout} exact path="/login" component={LoginPage} />
    <AppRoute layout={AuthorizedLayout} exact path="/products" component={ProductsPage} />

    <AppRoute layout={AdminLayout} exact path="/admin" component={DashboardAdminPage} />
    <AppRoute layout={AdminLayout} exact path="/admin/customers" component={CustomerAdminPage} />
    <AppRoute layout={AdminLayout} exact path="/admin/products" component={ProductAdminPage} />

    <AppRoute layout={GuestLayout} path="*" component={NotFoundPage} statusCode={404} />
</Switch>;