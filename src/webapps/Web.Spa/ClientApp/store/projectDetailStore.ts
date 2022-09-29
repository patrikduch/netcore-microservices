import { createSlice, PayloadAction, Dispatch } from '@reduxjs/toolkit';
import ProjectDetailService from '../services/ProjectDetailService';

export interface IProjectDetailStoreState {
    isFetching: boolean;
    name: string;
}

// Create the slice.
const slice = createSlice({
    name: "projectDetail",
    initialState: {
        isFetching: false,
        name: ''
    } as IProjectDetailStoreState,
    reducers: {
        setFetching: (state, action: PayloadAction<boolean>) => {
            state.isFetching = action.payload;
        },

        setProjectDetail: (state, action: PayloadAction<string>) => {
            state.name = action.payload;
        },
    }
});


// Export reducer from the slice.
export const { reducer } = slice;


// Define action creators.
export const actionCreators = {
    getProjectDetail: () => async (dispatch: Dispatch) => {
        dispatch(slice.actions.setFetching(true));

        const service = new ProjectDetailService();
        const result = await service.getDetails();

        debugger;

        if (!result.hasErrors) {
            dispatch(slice.actions.setProjectDetail(result.value.name));
        }
        
        dispatch(slice.actions.setFetching(false));
    }
};
