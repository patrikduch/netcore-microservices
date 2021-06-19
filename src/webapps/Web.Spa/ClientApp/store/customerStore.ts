import { IPersonModel } from '@Models/IPersonModel';
import { createSlice, PayloadAction, Dispatch } from '@reduxjs/toolkit';
import PersonService from '@Services/PersonService';

/**
 *  @type ICustomerStoreState Type definition for customer's slice of redux state.
 */
export interface ICustomerStoreState {
    isFetching: boolean;
    collection: IPersonModel[]
}

// Create the slice.
const slice = createSlice({
    name: "customers",
    initialState: {
        isFetching: false,
        collection: [],
    } as ICustomerStoreState,
    reducers: {
        setFetching: (state, action: PayloadAction<boolean>) => {
            state.isFetching = action.payload;
        },

        setCustomerData: (state, action: PayloadAction<IPersonModel[]>) => {
            state.collection = action.payload;
        },
    }
});


// Export reducer from the slice.
export const { reducer } = slice;


// Define action creators.
export const actionCreators = {
    getAll: () => async (dispatch: Dispatch) => {
        dispatch(slice.actions.setFetching(true));

        const service = new PersonService();
        const result = await service.getAll();

        if (!result.hasErrors) {
            dispatch(slice.actions.setCustomerData(result.value));
        }
        
        dispatch(slice.actions.setFetching(false));
    }
};
