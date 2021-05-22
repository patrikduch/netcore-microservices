import * as React from "react";
import { withStore } from "@Store/index";

/**
 * @class Project setup initialization component.
*/
class ProjectDetailContainer extends React.Component<any, any> {
    render() {
        return (
            <div>
                {
                    this.props.children
                }
            </div>
        );
    }
}

// Connect component with Redux store.
const connectedComponent = withStore(
    ProjectDetailContainer,
    state => state.projectDetail, // Selects which state properties are merged into the component's props.
    null,
);

// Attach the React Router to the component to have an opportunity
// to interract with it: use some navigation components, 
// have an access to React Router fields in the component's props, etc.
export default (connectedComponent);
