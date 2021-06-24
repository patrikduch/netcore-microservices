import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Helmet } from 'react-helmet';
import { withRouter } from 'react-router';
import { withStore } from "@Store/index";
import * as projectDetailStore from '@Store/projectDetailStore';
import { wait } from 'domain-wait';

import ContactUsHeadingTitle from '@Components/public-side/contact-us/heading-title/Contact-Us-Heading-Title';
import ContactUsBreadcrumb from '@Components/public-side/contact-us/contact-us-breads/Contact-Us-Breadcrumb';
import ContactUsFormContainer from '@Components/public-side/contact-us/Contact-Us-Form-Container';

/**
 * @interface IProps Component's props interface.
 */
interface IProps extends RouteComponentProps<{}> {
    getProjectDetail(): void;
}

/**
 * @interface IProps State's props interface.
 */
interface IState {}

/**
 * @class Entry page component for contact us information.
 */
class ContactPage extends React.Component<IProps, IState> {

    constructor(props: IProps) {
        super(props);

        wait(async () => {
            // Lets tell Node.js to wait for the request completion.
            // It's necessary when you want to see the fethched data 
            // in your prerendered HTML code (by SSR).
            //await this.props.getAll();
            //await this.props.getProjectDetail();
            await this.props.getProjectDetail();
        }, "contactpageTask");
    }

    render() {

        return (
            <div>
                <Helmet>
                    <meta data-react-helmet="true" name="title" content="E-commerce template | Contact"/>
                    <meta property="og:title" content="E-commerce template" />
                    <title>E-commerce template | Contact</title>
                </Helmet>

                <div className='container mt-4 page-container'>
                    <ContactUsHeadingTitle />
                    <ContactUsBreadcrumb />
                    <ContactUsFormContainer />
                </div>

               
                
        </div>
        );
    }
}


// Connect component with Redux store.
const connectedComponent = withStore(
    ContactPage,
    null, // Selects which state properties are merged into the component's props.
    {...projectDetailStore.actionCreators }, // Selects which action creators are merged into the component's props.
);

// Attach the React Router to the component to have an opportunity
// to interract with it: use some navigation components, 
// have an access to React Router fields in the component's props, etc.
export default withRouter(connectedComponent);