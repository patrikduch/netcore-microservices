import React from 'react';

import './Contact-Us-Breadcrumb.scss';

/**
 * @function ContactUsBreadcrumb Diplays small navigation for ContactUs page.
 */
const ContactUsBreadcrumb : React.FC = () => {

    return (
        <div className="row">
            <div className="col">
                <nav aria-label="breadcrumb">
                    <ol className="breadcrumb">
                        <li className="breadcrumb-item"><a href="#">Home</a></li>
                        <li className="breadcrumb-item active" aria-current="page">Contact</li>
                    </ol>
                </nav>
        </div>    
    </div>
    );
}

export default ContactUsBreadcrumb;