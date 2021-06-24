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
import Paginator from "@Components/shared/Paginator";
import { IProductModel } from "@Models/IProductModel";
import { paginate } from "@Utils";

type Props = typeof productStore.actionCreators & typeof projectDetailStore.actionCreators & productStore.IProductStoreState & RouteComponentProps<{}>;


interface IState {
    searchTerm: string;
    currentPageNum: number;
    limitPerPage: number;
    isAddModalOpen: boolean;
    isUpdateModalOpen: boolean;
    isDeleteModalOpen: boolean;
    modelForEdit?: IProductModel;
}

/**
 * @class ProductPage Entry page component for acccessing list of products.
 */
class ProductPage extends React.Component<Props, IState> {

    private paginator: Paginator;

    private debouncedSearch: (term: string) => void;

    private renderRows = (data: IProductModel[]) => {
        return paginate(data, this.state.currentPageNum, this.state.limitPerPage)
            .map(person =>
                <tr>
                    <td>{person.name}</td>
                    <td>{person.price} USD</td>
                </tr>
            );
    }

    constructor(props: Props) {
        super(props);


        this.state = {
            searchTerm: "",
            currentPageNum: 1,
            limitPerPage: 5,
            modelForEdit: null,
            isAddModalOpen: false,
            isDeleteModalOpen: false,
            isUpdateModalOpen: false
        };


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
                <title>E-commerce template | Products</title>
            </Helmet>
            
            <PageTitle>Product page</PageTitle>

            <table className="table">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Price</th><th></th>
                    </tr>
                </thead>
                <tbody>
                    {this.renderRows(this.props.collection)}
                </tbody>
            </table>

            <Paginator
                ref={x => this.paginator = x}
                totalResults={this.props.collection.length}
                limitPerPage={this.state.limitPerPage}
                currentPage={this.state.currentPageNum}
                onChangePage={(pageNum) => this.setState({ currentPageNum: pageNum })} />
        </Container>;
    }
}

// Connect component with Redux store.
const connectedComponent = withStore(
    ProductPage,
    state => state.products, // Selects which state properties are merged into the component's props.
    {...projectDetailStore.actionCreators, ...productStore.actionCreators}, // Selects which action creators are merged into the component's props.
);

// Attach the React Router to the component to have an opportunity
// to interract with it: use some navigation components, 
// have an access to React Router fields in the component's props, etc.
export default withRouter(connectedComponent);
