import React from 'react';
import './Contact-Us-Form.scss';

/**
 * @function ContactUsForm Form for sending new message to owner of e-commerce app.
 * @returns JSX with Formik form fields.
 */
const ContactUsForm: React.FC = () => {
    return (
        <div className="col">
            <div className="card">
                <div className="card-header bg-primary text-white">
                    <i className="fa fa-envelope"></i> Contact us.
                </div>
                
                <div className="card-body">
                    <form>
                        <div className="form-group">
                            <label htmlFor="name">Name</label>
                            <input type="text" className="form-control" id="name" aria-describedby="emailHelp" placeholder="Enter name" required />
                        </div>
                        
                        <div className="form-group">
                            <label htmlFor="email">Email address</label>
                            <input type="email" className="form-control" id="email" aria-describedby="emailHelp" placeholder="Enter email" required/>
                            <small id="emailHelp" className="form-text text-muted">We'll never share your email with anyone else.</small>
                        </div>

                        <div className="form-group">
                            <label htmlFor="message">Message</label>
                            <textarea className="form-control" id="message" rows={6} required></textarea>
                        </div>
                            
                        <div className="mx-auto">
                            <button type="submit" className="btn btn-primary text-right">Submit</button>
                        </div>    
                    </form>
                </div>
            </div>
        </div>
    );
};

export default ContactUsForm;