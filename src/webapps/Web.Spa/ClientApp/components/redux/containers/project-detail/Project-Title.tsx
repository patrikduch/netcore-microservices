import * as React from "react";
import { withStore } from "@Store/index";

/**
 * @interface IProps Component's props interface.
 */
interface IProps {
    name?: string; // Name of the web-application
}

/**
 * @function ProjectTitle Displays name of web-application.
 * @param name Current name of web-application.
 * @returns JSX for displaying name of web-application.
 */
const ProjectTitle: React.FC<IProps> = ({ name }) => {

    return (
        <>
            {name}
        </>
    )
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