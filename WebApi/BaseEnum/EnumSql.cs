namespace WebApi.BaseEnum
{
    public enum EnumSql 
    {
        #region Success

        SuccessWithInsert = 1,
        SuccessWithUpdate = 2,
        SuccessWithDelete = 3,

        #endregion

        #region Error
        //Default
        Error =   0,
        //insert
        RecordExist =   -1,
        //Update,Delete
        RecordNotExist =   -2

        #endregion
    }
}
