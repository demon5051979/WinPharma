export class GoodRequestModel {
    skip: number;
    take: number;
    expand: string;
    filter: string;
    orderby: string;
    orderDirection: string;

    constructor () {}
}
