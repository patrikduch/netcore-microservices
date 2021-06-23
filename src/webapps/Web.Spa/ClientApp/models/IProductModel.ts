/**
 * @interface IProductModel Interface for accessing product properties.
 */
export interface IProductModel {
    id: string;
    name: string;
    category: string;
    summary: string;
    description: string;
    imageFile: string;
    price: number;
}
