import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Helmet } from 'react-helmet';
import { withRouter } from 'react-router';
import { withStore } from "@Store/index";
import * as projectDetailStore from '@Store/projectDetailStore';
import { wait } from 'domain-wait';
import PageTitle from '@Components/common/headings/page-title/Page-Title';


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
 * @class Entry Basket Page component for root route of the web application.
 */
class BasketPage extends React.Component<IProps, IState> {

    constructor(props: IProps) {
        super(props);

        wait(async () => {
            // Lets tell Node.js to wait for the request completion.
            // It's necessary when you want to see the fethched data 
            // in your prerendered HTML code (by SSR).
            //await this.props.getAll();
            //await this.props.getProjectDetail();
            await this.props.getProjectDetail();
        }, "basketPageTask");
    }

    render() {

        return (
            <div>
                <Helmet>
                    <meta data-react-helmet="true" name="title" content="E-commerce template | Basket"/>
                    <meta property="og:title" content="E-commerce template" />
                    <title>E-commerce template | Basket</title>
                </Helmet>

                <div className='container mt-4 page-container'>
                    <PageTitle>Basket</PageTitle>
                </div>
            </div>
        );
    }
}


// Connect component with Redux store.
const connectedComponent = withStore(
    BasketPage,
    null, // Selects which state properties are merged into the component's props.
    {...projectDetailStore.actionCreators }, // Selects which action creators are merged into the component's props.
);

// Attach the React Router to the component to have an opportunity
// to interract with it: use some navigation components, 
// have an access to React Router fields in the component's props, etc.
export default withRouter(connectedComponent);