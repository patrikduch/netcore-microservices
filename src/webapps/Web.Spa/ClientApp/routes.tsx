import * as React from 'react';
import GuestLayout from "@Layouts/GuestLayout";
import AuthorizedLayout from '@Layouts/AuthorizedLayout';
import AppRoute from "@Components/shared/AppRoute";
import HomePage from '@Pages/public-side/Home-Page';
import { Switch } from 'react-router-dom';
import NotFoundPage from '@Pages/NotFound-Page';
import LoginPage from '@Pages/public-side/Login-Page';
import ProductsPage from '@Pages/public-side/Product-Page';
import AdminLayout from '@Layouts/Admin-Layout';
import CustomerAdminPage from '@Pages/admin/Customer-Admin-Page';
import ProductAdminPage from '@Pages/admin/Product-Admin-Page';
import DashboardAdminPage from '@Pages/admin/Dashboard-Admin-Page';
import ContactPage from '@Pages/public-side/Contact-Page';
import OrderPage from '@Pages/public-side/Order-Page';
import BasketCartPage from '@Pages/public-side/Basket-Cart-Page';

export const routes = <Switch>
    <AppRoute layout={AuthorizedLayout} exact path="/" component={HomePage} />
    <AppRoute layout={AuthorizedLayout} exact path="/cart" component={BasketCartPage} />
    <AppRoute layout={AuthorizedLayout} exact path="/login" component={LoginPage} />
    <AppRoute layout={AuthorizedLayout} exact path="/products" component={ProductsPage} />
    <AppRoute layout={AuthorizedLayout} exact path="/contact" component={ContactPage} />
    <AppRoute layout={AuthorizedLayout} exact path="/orders" component={OrderPage} />


    <AppRoute layout={AdminLayout} exact path="/admin" component={DashboardAdminPage} />
    <AppRoute layout={AdminLayout} exact path="/admin/customers" component={CustomerAdminPage} />
    <AppRoute layout={AdminLayout} exact path="/admin/products" component={ProductAdminPage} />

    <AppRoute layout={GuestLayout} path="*" component={NotFoundPage} statusCode={404} />
</Switch>;