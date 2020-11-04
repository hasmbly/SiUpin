﻿namespace SiUpin.WebUI.Common
{
    public static class Constants
    {
        public const string Bearer = "Bearer";

        public static class URI
        {
            public const string BaseAPI = "api";

            public static class Dev
            {
                public static readonly string GetFortifexOption = $"{BaseAPI}/dev/getFortifexOption";
            }

            public static class Account
            {
                public static readonly string CheckUsername = $"{BaseAPI}/account/checkUsername";
                public static readonly string Login = $"{BaseAPI}/account/login";
                public static readonly string GetMember = $"{BaseAPI}/account/getMember";
                public static readonly string ActivateMember = $"{BaseAPI}/account/activate?code=";
            }

            public static class Members
            {
                public static readonly string CreateMember = $"{BaseAPI}/members/createMember";
                public static readonly string UpdateMember = $"{BaseAPI}/members/updateMember";

                public static readonly string GetPreferences = $"{BaseAPI}/members/getPreferences";
                public static readonly string UpdatePreferredTimeFrame = $"{BaseAPI}/members/updatePreferredTimeFrame";
                public static readonly string UpdatePreferredCoinCurrency = $"{BaseAPI}/members/updatePreferredCoinCurrency";
                public static readonly string UpdatePreferredFiatCurrency = $"{BaseAPI}/members/updatePreferredFiatCurrency";
                public static readonly string GetTransactionsByMemberUsername = $"{BaseAPI}/members/getTransactionsByMemberUsername";
            }

            public static class Tools
            {
                public static readonly string GetPriceConversion = $"{BaseAPI}/tools/getPriceConversion";
                public static readonly string GetUnitPrice = $"{BaseAPI}/tools/getUnitPrice";
                public static readonly string GetUnitPriceInUSD = $"{BaseAPI}/tools/getUnitPriceInUSD";
            }

            public static class TimeFrames
            {
                public static readonly string GetAllTimeFrames = $"{BaseAPI}/timeFrames/getAllTimeFrames";
            }

            public static class Genders
            {
                public static readonly string GetAllGenders = $"{BaseAPI}/genders/getAllGenders";
            }

            public static class Regions
            {
                public static readonly string GetRegions = $"{BaseAPI}/regions/getRegions";
            }

            public static class Blockchains
            {
                public static readonly string GetAllBlockchains = $"{BaseAPI}/blockchains/getAllBlockchains";
            }

            public static class Countries
            {
                public static readonly string GetAllCountries = $"{BaseAPI}/countries/getAllCountries";
            }

            public static class Currencies
            {
                public static readonly string GetCurrency = $"{BaseAPI}/currencies/getCurrency";
                public static readonly string GetAvailableCurrencies = $"{BaseAPI}/currencies/getAvailableCurrencies";
                public static readonly string GetDestinationCurrenciesForMember = $"{BaseAPI}/currencies/getDestinationCurrenciesForMember";
                public static readonly string GetAllCoinCurrencies = $"{BaseAPI}/currencies/getAllCoinCurrencies";
                public static readonly string GetAllFiatCurrencies = $"{BaseAPI}/currencies/getAllFiatCurrencies";
                public static readonly string GetPreferableCoinCurrencies = $"{BaseAPI}/currencies/getPreferableCoinCurrencies";
                public static readonly string GetDistinctCurrenciesByMemberID = $"{BaseAPI}/currencies/getDistinctCurrenciesByMemberID";
            }

            public static class Wallets
            {
                public static readonly string GetPersonalWallets = $"{BaseAPI}/wallets/getPersonalWallets";
                public static readonly string GetMyPersonalWallets = $"{BaseAPI}/wallets/getMyPersonalWallets";
                public static readonly string GetWallet = $"{BaseAPI}/wallets/getWallet";
                public static readonly string GetPocket = $"{BaseAPI}/wallets/getPocket";
                public static readonly string CreateExchangeWallet = $"{BaseAPI}/wallets/createExchangeWallet";
                public static readonly string CreatePersonalWallet = $"{BaseAPI}/wallets/createPersonalWallet";
                public static readonly string UpdatePersonalWallet = $"{BaseAPI}/wallets/updatePersonalWallet";
                public static readonly string DeleteWallet = $"{BaseAPI}/wallets/deleteWallet";

                public static readonly string GetSyncPersonalWallet = $"{BaseAPI}/wallets/sync/details";
                public static readonly string SyncPersonalWallet = $"{BaseAPI}/wallets/syncPersonalWallet";
                public static readonly string UpdateDetailsSyncPersonalWallet = $"{BaseAPI}/wallets/sync/edit";

                public static readonly string GetStartingBalance = $"{BaseAPI}/wallets/getStartingBalance";
                public static readonly string UpdateStartingBalance = $"{BaseAPI}/wallets/updateStartingBalance";
            }

            public static class InternalTransfers
            {
                public static readonly string GetInternalTransfer = $"{BaseAPI}/internalTransfers/getInternalTransfer";
                public static readonly string CreateInternalTransfer = $"{BaseAPI}/internalTransfers/createInternalTransfer";
                public static readonly string UpdateInternalTransfer = $"{BaseAPI}/internalTransfers/updateInternalTransfer";
                public static readonly string DeleteInternalTransfer = $"{BaseAPI}/internalTransfers/deleteInternalTransfer";
                public static readonly string GetWalletsWithSameCurrency = $"{BaseAPI}/internalTransfers/getWalletsWithSameCurrency";
                public static readonly string GetAllWalletsWithSameCurrency = $"{BaseAPI}/internalTransfers/getAllWalletsWithSameCurrency";
            }

            public static class ExternalTransfers
            {
                public static readonly string GetExternalTransfer = $"{BaseAPI}/externalTransfers/getExternalTransfer";
                public static readonly string CreateExternalTransfer = $"{BaseAPI}/externalTransfers/createExternalTransfer";
                public static readonly string UpdateExternalTransfer = $"{BaseAPI}/externalTransfers/updateExternalTransfer";
                public static readonly string DeleteExternalTransfer = $"{BaseAPI}/externalTransfers/deleteExternalTransfer";
            }

            public static class Owners
            {
                public static readonly string GetOwner = $"{BaseAPI}/owners/getOwner";
                public static readonly string GetOwners = $"{BaseAPI}/owners/getOwners";
                public static readonly string GetProvider = $"{BaseAPI}/owners/getProvider";
                public static readonly string GetExchangeOwners = $"{BaseAPI}/owners/getExchangeOwners";
                public static readonly string GetAvailableExchangeProviders = $"{BaseAPI}/owners/getAvailableExchangeProviders";
                public static readonly string CreateExchangeOwner = $"{BaseAPI}/owners/createExchangeOwner";
                public static readonly string UpdateExchangeOwner = $"{BaseAPI}/owners/updateExchangeOwner";
                public static readonly string DeleteOwner = $"{BaseAPI}/owners/deleteOwner";
            }

            public static class Trades
            {
                public static readonly string GetTrade = $"{BaseAPI}/trades/getTrade";
                public static readonly string CreateTrade = $"{BaseAPI}/trades/createTrade";
                public static readonly string UpdateTrade = $"{BaseAPI}/trades/updateTrade";
                public static readonly string DeleteTrade = $"{BaseAPI}/trades/deleteTrade";
            }

            public static class Projects
            {
                public static readonly string CreateProject = $"{BaseAPI}/projects/createProject";
                public static readonly string UpdateProject = $"{BaseAPI}/projects/updateProject";
                public static readonly string DeleteContributors = $"{BaseAPI}/projects/deleteContributors";
                public static readonly string InviteMembers = $"{BaseAPI}/projects/inviteMembers";
                public static readonly string UpdateInvitation = $"{BaseAPI}/projects/updateInvitation";
                public static readonly string UpdateProjectStatus = $"{BaseAPI}/projects/updateProjectStatus";
                public static readonly string AcceptProjectInvitation = $"{BaseAPI}/projects/acceptProjectInvitation";
                public static readonly string RejectProjectInvitation = $"{BaseAPI}/projects/rejectProjectInvitation";

                public static readonly string GetMyProjects = $"{BaseAPI}/projects/getMyProjects";
                public static readonly string GetProject = $"{BaseAPI}/projects/getProject";
                public static readonly string GetProjectIsExist = $"{BaseAPI}/projects/getProjectIsExist";
                public static readonly string GetContributorsByMemberUsername = $"{BaseAPI}/projects/getContributorsByMemberUsername";
                public static readonly string GetProjectsConfirmation = $"{BaseAPI}/projects/getProjectsConfirmation";
                public static readonly string GetProjectStatusLogsByProjectID = $"{BaseAPI}/projects/getProjectStatusLogsByProjectID";
                public static readonly string CheckIsContributor = $"{BaseAPI}/projects/checkIsContributor";
            }

            public static class ProjectsDocument
            {
                public static readonly string CreateProjectDocument = $"{BaseAPI}/projectsDocument/createProjectDocument";
                public static readonly string GetProjectDocument = $"{BaseAPI}/projectsDocument/getProjectDocument";
                public static readonly string GetProjectDocumentDownload = $"{BaseAPI}/projectsDocument/getProjectDocument/download";
                public static readonly string UpdateProjectDocument = $"{BaseAPI}/projectsDocument/updateProjectDocument";
                public static readonly string DeleteProjectDocument = $"{BaseAPI}/projectsDocument/deleteProjectDocument";
            }

            public static class Portfolio
            {
                public static readonly string GetPortfolio = $"{BaseAPI}/portfolio/getPortfolio";
            }

            public static class StartingBalance
            {
                public static readonly string GetStartingBalance = $"{BaseAPI}/startingBalance/getStartingBalance";
                public static readonly string UpdateStartingBalance = $"{BaseAPI}/startingBalance/updateStartingBalance";
            }

            public static class Charts
            {
                public static readonly string GetPortfolioByCoinsV2 = $"{BaseAPI}/charts/getPortfolioByCoinsV2";
                public static readonly string GetPortfolioByExchanges = $"{BaseAPI}/charts/getPortfolioByExchanges";
                public static readonly string GetCoinByExchanges = $"{BaseAPI}/charts/getCoinByExchanges";
            }
        }

        public static class AlertMessageStatus
        {
            public const string Success = "alert-success";
            public const string Warning = "alert-warning";
        }

        public static class StorageKey
        {
            public const string Token = "Token";
        }

        public static class AuthenticationType
        {
            public const string ServerAuthentication = "ServerAuthentication";
        }
    }
}