import React from 'react';

/**
 * @function ContactUsHeadingTitle Displays heading title for ContactUs page.
 * @returns JSX with static content.
 */
const ContactUsHeadingTitle: React.FC = () => {

    return (
        <section className="jumbotron text-center">
            <div className="container">
                <h1 className="jumbotron-heading">E-COMMERCE CONTACT</h1>
                <p className="lead text-muted mb-0">Contact Page build with Bootstrap 4 !</p>
            </div>
        </section>
    );
}

export default ContactUsHeadingTitle;