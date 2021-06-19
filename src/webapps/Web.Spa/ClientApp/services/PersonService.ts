import Result from "@Core/Result";
import { ServiceBase } from "@Core/ServiceBase";
import { IPersonModel } from "@Models/IPersonModel";

/**
 * @class PersonService  Data manipulation classs for manaing persons (customers).
 */
export default class PersonService extends ServiceBase {
    /**
     * @function getAll Fetch all customers without restrictions.
     * @returns Collection of Persons (Customers).
     */
    public async getAll(): Promise<Result<IPersonModel[]>> {
        var result = await this.requestJson<IPersonModel[]>({
            url: `/Customer`,
            method: "GET"
        });

        return result;
    }
}