import React from 'react';
import './Page-Title.scss';

/**
 * @function PageTitle Common component for rendering top level heading.
 * @param children Content that will be rendered. 
 * @returns Top level heading element (h1).
 */
const PageTitle: React.FC = ({ children }) => {

    return (
        <h1 className="mb-4">{ children }</h1>
    );
}

export default PageTitle;