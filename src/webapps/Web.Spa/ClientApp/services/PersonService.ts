import Result from "@Core/Result";
import { ServiceBase } from "@Core/ServiceBase";
import SessionManager, { IServiceUser } from "@Core/session";
import { IPersonModel } from "@Models/IPersonModel";

export default class PersonService extends ServiceBase {

    public async search(term: string = null): Promise<any> {
        if (term == null) {
            term = "";
        }
        var result = await this.requestJson<any>({
            url: `http://20.86.197.55/Customer`,
            method: "GET"
        });

        debugger;

        return result;
    }

    public async update(model: IPersonModel): Promise<Result<{}>> {
        var result = await this.requestJson({
            url: `/api/Person/${model.id}`,
            method: "PATCH",
            data: model
        });
        return result;
    }

    public async delete(id: number): Promise<Result<{}>> {
        var result = await this.requestJson({
            url: `/api/Person/${id}`,
            method: "DELETE"
        });
        return result;
    }

    public async add(model: IPersonModel): Promise<Result<number>> {
        var result = await this.requestJson<number>({
            url: "/api/Person/Add",
            method: "POST",
            data: model
        });
        return result;
    }
}