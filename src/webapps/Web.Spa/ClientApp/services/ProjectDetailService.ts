import Result from "@Core/Result";
import { ServiceBase } from "@Core/ServiceBase";
import { IProjectDetailModel } from "../models/IProjectDetailModel";

export default class ProjectDetailService extends ServiceBase {

    public async getDetails(): Promise<Result<IProjectDetailModel>> {
      
        var result = await this.requestJson<IProjectDetailModel>({
            url: `/api/project`,
            method: "GET"
        });
        return result;
    }
}