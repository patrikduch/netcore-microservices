import Result from "@Core/Result";
import { ServiceBase } from "@Core/ServiceBase";
import { IPersonModel } from "@Models/IPersonModel";
import { IProductModel } from "@Models/IProductModel";

/**
 * @class ProductService  Data manipulation classs for managing list of available products.
 */
export default class ProductService extends ServiceBase {
    /**
     * @function getProducts Fetch all products without restrictions.
     * @returns Collection of products.
     */
    public async getProducts(): Promise<Result<IProductModel[]>> {
        var result = await this.requestJson<IProductModel[]>({
            url: `/Catalog`,
            method: "GET"
        });

        return result;
    }
}