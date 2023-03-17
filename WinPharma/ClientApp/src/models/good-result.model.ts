import { DataModel } from "./data.model";

export class GoodResult {
    result: GoodResultData;
    status: string;
    requestId: string;
    isFreshData: boolean;
}


export class GoodResultData {
    totalItems: number;
	items: DataModel[]
}
