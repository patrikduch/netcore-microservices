import React from 'react';
import ContactUsFormAddress from './contact-us-address/Contact-Us-Address';
import ContactUsForm from './contact-us-form/Contact-Us-Form';

/**
 * @function ContactUsFormContainer Encapsulation component of main content of ContactUs page.
 * @returns JSX with two nested custom components "ContactUsForm", "ContactUsFormAddress".
 */
const ContactUsFormContainer: React.FC = () => {
    return (
        <div className="row">
            <ContactUsForm />
            <ContactUsFormAddress />
        </div>
    );
}

export default ContactUsFormContainer;