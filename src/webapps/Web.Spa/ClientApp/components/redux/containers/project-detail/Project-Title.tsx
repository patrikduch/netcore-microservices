import * as React from "react";
import { withStore } from "@Store/index";



class ProjectTitle extends React.Component<any, any> {

    render() {

        return (

            <div>
                Ecommerce-Template

            </div>
        );
    }
}


// Connect component with Redux store.
const connectedComponent = withStore(
    ProjectTitle,
    state => state.projectDetail, // Selects which state properties are merged into the component's props.
    null
);

// Attach the React Router to the component to have an opportunity
// to interract with it: use some navigation components, 
// have an access to React Router fields in the component's props, etc.
export default (connectedComponent);