import * as React from "react";
import "@Styles/authorizedLayout.scss";
import { ToastContainer } from "react-toastify";
import Footer from "@Components/shared/footer/Footer-Container";
import NavigationBar from "@Components/public-side/shared/navigation/navigation-bar/Navigation-Bar";

interface IProps {
    children?: React.ReactNode;
}

type Props = IProps;

export default class AuthorizedLayout extends React.Component<Props, {}> {
    render() {
        return (
                <div id="authorizedLayout" className="layout">
                    <NavigationBar />
                    {this.props.children}
                    <ToastContainer />
                    <Footer />
                </div>
        );
    }
}