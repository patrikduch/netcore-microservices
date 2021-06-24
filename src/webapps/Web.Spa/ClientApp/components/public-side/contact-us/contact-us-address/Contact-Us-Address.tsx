import React from 'react';
import './Contact-Us-Container.scss';

/**
 * @function ContactUsAddress Display information about author's personal address.
 * @returns JSX that renders static content of author's  personal address.
 */
const ContactUsAddress: React.FC = () => {

    return (
        <div className="col-12 col-sm-4">
            <div className="card bg-light mb-3">
                <div className="card-header bg-success text-white text-uppercase"><i className="fa fa-home"></i> Address</div>
                <div className="card-body">
                    <p>Ostravská 1619/48</p>
                    <p>73701 Český Těšín</p>
                    <p>Czech Republic</p>
                    <p>Email : duchpatrik@icloud.com</p>
                    <p>Tel. +420 604 102 832</p>
                </div>
            </div>
        </div>
    );
}

export default ContactUsAddress;