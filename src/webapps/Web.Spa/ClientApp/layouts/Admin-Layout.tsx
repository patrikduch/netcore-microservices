import * as React from "react";
import "@Styles/authorizedLayout.scss";
import NavigationBar from "@Components/admin/shared/navigation/navigation-bar/Navigation-Bar";

/**
 * @interface IProps Component's props interface.
 */
interface IProps {
    children?: React.ReactNode;
}

type Props = IProps;

/**
 * @class AdminLayout Skeleton for administration's components.
 * @returns JSX with encapsulation page component.
 */
class AdminLayout extends React.Component<Props, {}> {
    render() {
        return (
            <>
                <NavigationBar />
                <div id="adminLayout" className="layout">
                    {this.props.children}
                </div>
           </>
        );
    }
}

export default AdminLayout;