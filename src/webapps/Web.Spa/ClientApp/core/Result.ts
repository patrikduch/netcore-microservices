export default class Result<T> {
    public value: T;
    public errors: string[];
    public get hasErrors(): boolean {
        debugger;
        return this.errors != null && Array.isArray(this.errors) && this.errors.length > 0;
    }

    constructor(value: T, ...errors: string[]) {
        this.value = value;
        debugger;
        this.errors = errors[0] == undefined || errors[0] == null ? [] : errors;
    }
}