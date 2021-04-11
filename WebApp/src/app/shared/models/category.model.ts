declare module namespace {

    export interface SubCategory {
        name: string;
        parentId: number;
        subCategories?: any;
        id: number;
        softDeleted: boolean;
        createdAt: Date;
        modifiedAt?: any;
    }

    export interface RootObject {
        name: string;
        parentId?: any;
        subCategories: SubCategory[];
    }

}