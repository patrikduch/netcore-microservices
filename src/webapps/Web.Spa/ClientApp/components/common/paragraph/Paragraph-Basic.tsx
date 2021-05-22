import React from 'react';

import './Paragraph-Basic.scss';

/**
 * @function ParagraphBasic Standard common paragraph commponent.
 */
const ParagraphBasic: React.FC  = ({ children }) => {

    return (
        <p className='paragraph-basic'>{ children }</p>
    );
}

export default ParagraphBasic;