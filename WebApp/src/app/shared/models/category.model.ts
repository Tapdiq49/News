export interface ICategory {
    name: string;
    parentId?: any;
    subCategories: ICategory[];
}

