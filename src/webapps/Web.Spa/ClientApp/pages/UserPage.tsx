import "@Styles/main.scss";
import * as React from "react";
import { Helmet } from "react-helmet";
import { RouteComponentProps, withRouter } from "react-router";
import { IPersonModel } from "@Models/IPersonModel";
import * as personStore from "@Store/personStore";
import { withStore } from "@Store/index";
import Paginator from "@Components/shared/Paginator";
import AwesomeDebouncePromise from "awesome-debounce-promise";
import { paginate, getPromiseFromActionCreator } from "@Utils";
import { Modal, Button, Container, Row, Card } from "react-bootstrap";
import { wait } from "domain-wait";
import * as projectDetailStore from '@Store/projectDetailStore';

type Props = typeof personStore.actionCreators & typeof projectDetailStore.actionCreators & personStore.IPersonStoreState & RouteComponentProps<{}>;


interface IState {
    searchTerm: string;
    currentPageNum: number;
    limitPerPage: number;
    isAddModalOpen: boolean;
    isUpdateModalOpen: boolean;
    isDeleteModalOpen: boolean;
    modelForEdit?: IPersonModel;
}

class UserPage extends React.Component<Props, IState> {

    private paginator: Paginator;

    private debouncedSearch: (term: string) => void;

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

        // "AwesomeDebouncePromise" makes a delay between
        // the end of input term and search request.
        this.debouncedSearch = AwesomeDebouncePromise((term: string) => {
            props.search(term);
        }, 500);



        wait(async () => {
            // Lets tell Node.js to wait for the request completion.
            // It's necessary when you want to see the fethched data 
            // in your prerendered HTML code (by SSR).
            await this.props.search();
        }, "examplesPageTask");

        wait(async () => {
            // Lets tell Node.js to wait for the request completion.
            // It's necessary when you want to see the fethched data 
            // in your prerendered HTML code (by SSR).
            await this.props.getProjectDetail();
        }, "projectDetailTask");
    }

    private renderRows = (data: IPersonModel[]) => {
        return paginate(data, this.state.currentPageNum, this.state.limitPerPage)
            .map(person =>
                <tr key={person.id}>
                    <td>{person.firstName}</td>
                    <td>{person.lastName}</td>
                </tr>
            );
    }   
    render() {

        return <Container className='page-container'>

            <Helmet>
                <meta data-react-helmet="true" name="title" content="E-commerce template | Users"/>
                <meta property="og:title" content="E-commerce template | Users" />
                <title>E-commerce template | Users</title>
            </Helmet>
    
            <h1 className='mb-4'>User list</h1>
            <table className="table">
                <thead>
                    <tr>
                        <th>First name</th>
                        <th>Last name</th><th></th>
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
    UserPage,
    state => state.person, // Selects which state properties are merged into the component's props.
    {...personStore.actionCreators, ...projectDetailStore.actionCreators}, // Selects which action creators are merged into the component's props.
);

// Attach the React Router to the component to have an opportunity
// to interract with it: use some navigation components, 
// have an access to React Router fields in the component's props, etc.
export default withRouter(connectedComponent);
