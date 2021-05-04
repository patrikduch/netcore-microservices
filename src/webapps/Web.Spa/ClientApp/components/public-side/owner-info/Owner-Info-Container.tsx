import React from 'react';
import './Owner-Info-Container.scss';

/**
 * @function OwnerInfoContainer Encapsulation component that contains styling of ownerinfo block.
 */
const OwnerInfoContainer: React.FC<any> = () => {

    return (
        <div className='col-sm-4 ownerinfo-container'>
            <h3 className='ownerinfo-container__heading'>Contact Me</h3>
            <p className='ownerinfo-container__paragraph'>Bc. Patrik Duch</p>
            <p className='ownerinfo-container__paragraph'>Enterprise Solutions Architect</p>
            <p className='ownerinfo-container__paragraph'>Ostravská 1619/48</p>
            <p className='ownerinfo-container__paragraph'>73701</p>
            <p className='ownerinfo-container__paragraph'>Český Těšín</p>
            <p className='ownerinfo-container__paragraph'>IČ: 09225471</p>
        </div>
    );
}

export default OwnerInfoContainer;