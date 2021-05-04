import React from 'react';
import './Anchor-Basic.scss';

/**
 * @interface IProps 
 */
interface IProps {

    targetUrl: string;
    labelUrl: string;
}

/**
 * @function AnchorBasic Common shared anchor tag component for reproducing basic link elements.
 */
const AnchorBasic: React.FC<IProps> = ({ labelUrl, targetUrl}) => {
    return (
        <a className='anchor-basic' href={targetUrl}>{labelUrl}</a>
    );
}

export default AnchorBasic;