Public Class Updater
#Region "Box"
    Public Delegate Sub BoxEventHandler(ByVal bx As OrphanageClasses.Box)
    Public Delegate Sub DelBoxEventHandler(ByVal bx_id As Integer)
    Public Shared Event NewBox As BoxEventHandler
    Public Shared Sub AddNewBox(ByVal bx As OrphanageClasses.Box)
        RaiseEvent NewBox(bx)
    End Sub
    Public Shared Event UpdateBox As BoxEventHandler
    Public Shared Sub UpdatesBox(ByVal bx As OrphanageClasses.Box)
        RaiseEvent UpdateBox(bx)
    End Sub
    Public Shared Event DeleteBox As DelBoxEventHandler
    Public Shared Sub DeletesBox(ByVal bx_id As Integer)
        RaiseEvent DeleteBox(bx_id)
    End Sub
#End Region
#Region "Orphan"
    Public Delegate Sub OrphanEventHandler(ByVal bx As OrphanageClasses.Orphan)
    Public Delegate Sub DelOrphanEventHandler(ByVal Orph_id As Integer)
    Public Shared Event NewOrphan As OrphanEventHandler
    Public Shared Sub AddNewOrphan(ByVal orph As OrphanageClasses.Orphan)
        RaiseEvent NewOrphan(orph)
    End Sub
    Public Shared Event UpdateOrphan As OrphanEventHandler
    Public Shared Sub UpdatesOrphan(ByVal orph As OrphanageClasses.Orphan)
        RaiseEvent UpdateOrphan(orph)
    End Sub
    Public Shared Event DeleteOrphan As DelOrphanEventHandler
    Public Shared Sub DeletesOrphan(ByVal orph_id As Integer)
        RaiseEvent DeleteOrphan(orph_id)
    End Sub
#End Region
#Region "Father"
    Public Delegate Sub FatherEventHandler(ByVal bx As OrphanageClasses.Father)
    Public Delegate Sub DelFatherEventHandler(ByVal bx As Integer)
    Public Shared Event NewFather As FatherEventHandler
    Public Shared Sub AddNewFather(ByVal fath As OrphanageClasses.Father)
        RaiseEvent NewFather(fath)
    End Sub
    Public Shared Event UpdateFather As FatherEventHandler
    Public Shared Sub UpdatesFather(ByVal fath As OrphanageClasses.Father)
        RaiseEvent UpdateFather(fath)
    End Sub
    Public Shared Event DeleteFather As DelFatherEventHandler
    Public Shared Sub DeletesFather(ByVal fath_id As Integer)
        RaiseEvent DeleteFather(fath_id)
    End Sub
#End Region
#Region "Family"
    Public Delegate Sub FamilyEventHandler(ByVal bx As OrphanageClasses.Family)
    Public Delegate Sub DelFamilyEventHandler(ByVal bx As Integer)
    Public Shared Event NewFamily As FamilyEventHandler
    Public Shared Sub AddNewFamily(ByVal fam As OrphanageClasses.Family)
        RaiseEvent NewFamily(fam)
    End Sub
    Public Shared Event UpdateFamily As FamilyEventHandler
    Public Shared Sub UpdatesFamily(ByVal fam As OrphanageClasses.Family)
        RaiseEvent UpdateFamily(fam)
    End Sub
    Public Shared Event DeleteFamily As DelFamilyEventHandler
    Public Shared Sub DeletesFamily(ByVal fam_id As Integer)
        RaiseEvent DeleteFamily(fam_id)
    End Sub
#End Region
#Region "Mother"
    Public Delegate Sub MotherEventHandler(ByVal bx As OrphanageClasses.Mother)
    Public Delegate Sub DelMotherEventHandler(ByVal Moth_Id As Integer)
    Public Shared Event NewMother As MotherEventHandler
    Public Shared Sub AddNewMother(ByVal bx As OrphanageClasses.Mother)
        RaiseEvent NewMother(bx)
    End Sub
    Public Shared Event UpdateMother As MotherEventHandler
    Public Shared Sub UpdatesMother(ByVal Moth As OrphanageClasses.Mother)
        RaiseEvent UpdateMother(Moth)
    End Sub
    Public Shared Event DeleteMother As DelMotherEventHandler
    Public Shared Sub DeletesMother(ByVal Moth_ID As Integer)
        RaiseEvent DeleteMother(Moth_ID)
    End Sub
#End Region
#Region "BondsMan"
    Public Delegate Sub BondsManEventHandler(ByVal bx As Integer)
    Public Delegate Sub DelBondsManEventHandler(ByVal Bond_ID As Integer)
    Public Shared Event NewBondsMan As BondsManEventHandler
    Public Shared Sub AddNewBondsMan(ByVal bond As Integer)
        RaiseEvent NewBondsMan(bond)
    End Sub
    Public Shared Event UpdateBondsMan As BondsManEventHandler
    Public Shared Sub UpdatesBondsMan(ByVal bond As Integer)
        RaiseEvent UpdateBondsMan(bond)
    End Sub
    Public Shared Event DeleteBondsMan As DelBondsManEventHandler
    Public Shared Sub DeletesBondsMan(ByVal bond_ID As Integer)
        RaiseEvent DeleteBondsMan(bond_ID)
    End Sub
#End Region
#Region "Bail"
    Public Delegate Sub BailEventHandler(ByVal bx As OrphanageClasses.Bail)
    Public Delegate Sub DelBailEventHandler(ByVal Bill_Id As Integer)
    Public Shared Event NewBail As BailEventHandler
    Public Shared Sub AddNewBail(ByVal bai As OrphanageClasses.Bail)
        RaiseEvent NewBail(bai)
    End Sub
    Public Shared Event UpdateBail As BailEventHandler
    Public Shared Sub UpdatesBail(ByVal bai As OrphanageClasses.Bail)
        RaiseEvent UpdateBail(bai)
    End Sub
    Public Shared Event DeleteBail As DelBailEventHandler
    Public Shared Sub DeletesBail(ByVal bai As Integer)
        RaiseEvent DeleteBail(bai)
    End Sub
#End Region
#Region "Supporter"
    Public Delegate Sub SupporterEventHandler(ByVal bx As OrphanageClasses.Supporter)
    Public Delegate Sub DelSupporterEventHandler(ByVal id As Integer)
    Public Shared Event NewSupporter As SupporterEventHandler
    Public Shared Sub AddNewSupporter(ByVal supp As OrphanageClasses.Supporter)
        RaiseEvent NewSupporter(supp)
    End Sub
    Public Shared Event UpdateSupporter As SupporterEventHandler
    Public Shared Sub UpdatesSupporter(ByVal supp As OrphanageClasses.Supporter)
        RaiseEvent UpdateSupporter(supp)
    End Sub
    Public Shared Event DeleteSupporter As DelSupporterEventHandler
    Public Shared Sub DeletesSupporter(ByVal supp_id As Integer)
        RaiseEvent DeleteSupporter(supp_id)
    End Sub
#End Region
#Region "User"
    Public Delegate Sub UserEventHandler(ByVal bx As OrphanageClasses.User)
    Public Delegate Sub DelUserEventHandler(ByVal bx_id As Integer)
    Public Shared Event NewUser As UserEventHandler
    Public Shared Sub AddNewUser(ByVal bx As OrphanageClasses.User)
        RaiseEvent NewUser(bx)
    End Sub
    Public Shared Event UpdateUser As UserEventHandler
    Public Shared Sub UpdatesUser(ByVal bx As OrphanageClasses.User)
        RaiseEvent UpdateUser(bx)
    End Sub
    Public Shared Event DeleteUser As DelUserEventHandler
    Public Shared Sub DeletesUser(ByVal bx_id As Integer)
        RaiseEvent DeleteUser(bx_id)
    End Sub
#End Region
#Region "Transform"
    Public Delegate Sub TransformEventHandler(ByVal bx As OrphanageClasses.Transform)
    Public Delegate Sub DelTransformEventHandler(ByVal bx_id As Integer)
    Public Shared Event NewTransform As TransformEventHandler
    Public Shared Sub AddNeWTransform(ByVal bx As OrphanageClasses.Transform)
        RaiseEvent NewTransform(bx)
    End Sub
    Public Shared Event DeleteTransform As DelTransformEventHandler
    Public Shared Sub DeletesTransform(ByVal bx_id As Integer)
        RaiseEvent DeleteTransform(bx_id)
    End Sub
#End Region
#Region "Bill"
    Public Delegate Sub BillEventHandler(ByVal bx As OrphanageClasses.Bill)
    Public Delegate Sub DelBillEventHandler(ByVal bx_id As Integer)
    Public Shared Event NewBill As BillEventHandler
    Public Shared Sub AddNewBill(ByVal bx As OrphanageClasses.Bill)
        RaiseEvent NewBill(bx)
    End Sub
    Public Shared Event DeleteBill As DelBillEventHandler
    Public Shared Sub DeletesBill(ByVal bx_id As Integer)
        RaiseEvent DeleteBill(bx_id)
    End Sub
#End Region


End Class
