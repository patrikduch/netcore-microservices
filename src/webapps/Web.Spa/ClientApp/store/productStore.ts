import { IProductModel } from '@Models/IProductModel';
import { createSlice, PayloadAction, Dispatch } from '@reduxjs/toolkit';
import PersonService from '@Services/PersonService';
import ProductService from '@Services/ProductService';

/**
 *  @type IProductStoreState Type definition for product's slice of redux state.
 */
export interface IProductStoreState {
    isFetching: boolean;
    collection: IProductModel[];
}

// Create the slice.
const slice = createSlice({
    name: "products",
    initialState: {
        isFetching: false,
        collection: [],
    } as IProductStoreState,
    reducers: {
        setFetching: (state, action: PayloadAction<boolean>) => {
            state.isFetching = action.payload;
        },

        setProductData: (state, action: PayloadAction<IProductModel[]>) => {
            state.collection = action.payload;
        },
    }
});


// Export reducer from the slice.
export const { reducer } = slice;


// Define action creators.
export const actionCreators = {
    getProducts: () => async (dispatch: Dispatch) => {
        dispatch(slice.actions.setFetching(true));

        const service = new ProductService();
        const result = await service.getProducts();

        if (!result.hasErrors) {
            dispatch(slice.actions.setProductData(result.value));
        }
        
        dispatch(slice.actions.setFetching(false));
    }
};
