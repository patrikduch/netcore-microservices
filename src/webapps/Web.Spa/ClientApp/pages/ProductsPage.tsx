import "@Styles/main.scss";
import * as React from "react";
import { Helmet } from "react-helmet";
import { RouteComponentProps, withRouter } from "react-router";
import { withStore } from "@Store/index";
import { Container } from "react-bootstrap";
import { wait } from "domain-wait";
import * as projectDetailStore from '@Store/projectDetailStore';
import * as productStore from '@Store/productStore';
import PageTitle from "@Components/common/headings/page-title/Page-Title";

type Props = typeof productStore.actionCreators & typeof projectDetailStore.actionCreators & productStore.IProductStoreState & RouteComponentProps<{}>;


interface IState {
    
}

class ProductPage extends React.Component<Props, IState> {

    constructor(props: Props) {
        super(props);

        wait(async () => {
            // Lets tell Node.js to wait for the request completion.
            // It's necessary when you want to see the fethched data 
            // in your prerendered HTML code (by SSR).
            //await this.props.getAll();
            //await this.props.getProjectDetail();
            await this.props.getProjectDetail();
            await this.props.getProducts();
        }, "productTask");
    }

   
    render() {

        return <Container className='page-container'>

            <Helmet>
                <meta data-react-helmet="true" name="title" content="E-commerce template | Users"/>
                <meta property="og:title" content="E-commerce template | Products" />
                <title>E-commerce template | Users</title>
            </Helmet>
            
            <PageTitle>Product page</PageTitle>

       

        </Container>;
    }
}

// Connect component with Redux store.
const connectedComponent = withStore(
    ProductPage,
    state => state.customers, // Selects which state properties are merged into the component's props.
    {...projectDetailStore.actionCreators, ...productStore.actionCreators}, // Selects which action creators are merged into the component's props.
);

// Attach the React Router to the component to have an opportunity
// to interract with it: use some navigation components, 
// have an access to React Router fields in the component's props, etc.
export default withRouter(connectedComponent);
